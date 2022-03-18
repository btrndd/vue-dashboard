import { formValidation } from './formValidation.js';
import { formatNumber } from './phoneMask.js';
import { executeMask } from './phoneMask.js';
import { redirectToUsers } from './redirectToUsers.js';
import { addZero } from './tableRows.js';


const formInjection = async (page) => {
  const main = document.querySelector('.main');
  main.innerHTML = '';
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newMain = newHtml.querySelector('.main');
  main.innerHTML = newMain.innerHTML;
}

const getData = async(data) => {
  const request = new Request(data + '.html');
  const response = await fetch(request);
  const page = await response.text();
  return page;
}

const getById = async (id) => {
  const request = await fetch(`https://localhost:7271/users/${id}`);
  const response = await request.json();
  return response;
}

const setValues = (userData) => {
  const keys = Object.keys(userData);
  const filteredKey = keys.slice(1,7);
  filteredKey.forEach((key) => {
    if (key === 'status') {
      document.getElementById(`${key}`).checked = userData[key]; 
    } else if (key === 'birthDate') {
      let currDate = new Date(userData[key]);
      let formatedDate = (currDate.getFullYear() + "-" +
       addZero(currDate.getMonth()+1).toString()  + "-" + addZero(currDate.getDate().toString()));
      document.getElementById(`${key}`).value = formatedDate;    
    } else if (key === 'phone') {
      const formatPhone = formatNumber(userData[key]);
      document.getElementById(`${key}`).value = formatPhone;    
    } else {      
      document.getElementById(`${key}`).value = userData[key];    
    }
  });
}

// Gerar form com SPA
const registerForm = async (ev, id, edit) => {
  const register = ev.target.id;
  const response = await getData(register);
  await formInjection(response);
  const submitBtn = document.querySelector('.register-btn');
  if (submitBtn && edit === 'edit') {
    const title = document.querySelector('.container-register h2');
    title.textContent = 'Usuários / Editar'
    submitBtn.textContent = 'Editar';
    submitBtn.name = 'edit';
    submitBtn.id = id;
    const cancel = document.createElement('button');
    cancel.type = 'button';
    cancel.textContent = 'Cancelar';
    cancel.classList.add('cancel-btn');
    cancel.addEventListener('click', redirectToUsers);
    const form = document.querySelector('.form');
    form.appendChild(cancel);
    const userData = await getById(id);
    setValues(userData);
    submitBtn.addEventListener('click', formValidation);
  }
  if (submitBtn && edit !== 'edit') {
    submitBtn.name = 'cadastrar';
    submitBtn.addEventListener('click', formValidation);
  }
  const phone = document.getElementById('phone');
  phone.addEventListener('keyup', () => {
    const adjustedPhone = formatNumber(phone.value);
    executeMask(phone, adjustedPhone);
  });
}

export { registerForm };