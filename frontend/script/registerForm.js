import { formValidation } from './formValidation.js';
import { formatNumber } from './phoneMask.js';
import { executeMask } from './phoneMask.js';
import { redirectToUsers } from './redirectToUsers.js';

const main = document.querySelector('.main');

const formInjection = async (page) => {
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
  const request = await fetch(`/users/${id}`);
  const response = await request.json();
  return response;
}

const setValues = (userData) => {
  const keys = Object.keys(userData);
  keys.forEach((key) => {
    document.getElementById(`${key}`).value = userData[key];    
  });
}

const registerForm = async (ev, edit) => {
  const { id } = ev.target;
  const response = await getData(id);
  await formInjection(response);
  const submitBtn = document.getElementById('cadastrar');
  if (submitBtn && edit == 'edit') {
    const title = document.querySelector('.container-register h2');
    title.textContent = 'Usuários / Editar'
    submitBtn.textContent = 'Editar';
    const cancel = document.createElement('button');
    cancel.type = 'button';
    cancel.textContent = 'Cancelar';
    cancel.classList.add('cancel-btn');
    cancel.addEventListener('click', redirectToUsers);
    const form = document.querySelector('.form');
    form.appendChild(cancel);
    const userData = await getById(id);
    setValues(userData);
    submitBtn.addEventListener('click', formValidation(edit));
  }
  if (submitBtn && edit !== 'edit') {
    submitBtn.addEventListener('click', formValidation);
  }
  const phone = document.getElementById('phone');
  phone.addEventListener('keyup', () => {
    const adjustedPhone = formatNumber(phone.value);
    executeMask(phone, adjustedPhone);
  });
}

export { registerForm };