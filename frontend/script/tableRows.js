import { editUser } from "./editUser.js";
import { formatNumber } from "./phoneMask.js";
import { confirmRemove } from "./confirmRemove.js";

const translateKeys = (key) => {
  switch (key) {
    case 'name':
      return 'Nome';
    case 'lastName':
      return 'Nome';
    case 'phone':
      return 'Telefone';
    case 'email':
      return 'Email';
    case 'birthDate':
      return 'Data Nasc.';
    case 'status':
      return 'Status';
  }
}

const addZero = (number) => {
  if (number <= 9) 
      return "0" + number;
  else
      return number; 
}

const insertAvatar = (user, index) => {
  const firstTds = document.querySelectorAll('.user-row');
  firstTds[index].firstChild.textContent = '';
  const wrapper = document.createElement('div');
  wrapper.classList.add('name-wrapper');
  const img = document.createElement('img');
  img.classList.add('list-avatar');
  img.src = "./img/avatar.png";
  const name = document.createElement('p');
  name.classList.add('name-text');
  name.textContent = `${user.name} ` + user.lastName;
  wrapper.appendChild(img);
  wrapper.appendChild(name);
  firstTds[index].firstChild.appendChild(wrapper);
}

const tableRows = (data) => {
  const tbody = document.querySelector('.tbody');
  const rows = document.querySelectorAll('.user-row');  
  if (rows) {
    rows.forEach((row) => tbody.removeChild(row));
  }
  data.forEach((user, index) => {
    const tr = document.createElement('tr');
    tr.classList.add('user-row');
    tbody.appendChild(tr);
    const keys = Object.keys(user);
    const filteredKey = keys.slice(2,7);
    filteredKey.forEach((key) => {
      if (user[key] === true) {
        const td = document.createElement('td');
        const translatedKey = translateKeys(key);
        td.setAttribute('data-title', translatedKey);
        const text = document.createElement('p');
        text.textContent = 'Ativo';
        text.classList.add('active');
        td.appendChild(text);
        tr.appendChild(td);
      } else if (user[key] === false) {
        const td = document.createElement('td');
        const translatedKey = translateKeys(key);
        td.setAttribute('data-title', translatedKey);
        const text = document.createElement('p');
        text.textContent = 'Inativo';
        text.classList.add('inactive');
        td.appendChild(text);
        tr.appendChild(td);
      } else if (key === 'birthDate') {
        const td = document.createElement('td');
        const translatedKey = translateKeys(key);
        td.setAttribute('data-title', translatedKey);
        let currDate = new Date(user[key]);
        let formatedDate = (addZero(currDate.getDate().toString()) 
        + "/" + (addZero(currDate.getMonth()+1).toString()) + "/" + currDate.getFullYear());
        td.textContent = formatedDate;
        tr.appendChild(td);
      } else if (key === 'phone') {
        const td = document.createElement('td');
        const translatedKey = translateKeys(key);
        td.setAttribute('data-title', translatedKey);
        const formatPhone = formatNumber(user[key]);
        td.textContent = formatPhone;
        tr.appendChild(td);
      } else {
        const td = document.createElement('td');
        const translatedKey = translateKeys(key);
        td.setAttribute('data-title', translatedKey);
        td.textContent = user[key];
        tr.appendChild(td);
      }    
    });
    insertAvatar(user, index);
    const acoes = document.createElement('td');
    const acoesWrapper = document.createElement('div');
    acoesWrapper.classList.add('acoes-wrapper');
    const edit = document.createElement('i');
    edit.classList.add('fas');
    edit.classList.add('fa-edit');
    edit.id = user.id;
    edit.setAttribute('data-name', 'edit');
    const editBtn = document.createElement('button');
    editBtn.type = 'button';
    editBtn.id = user.id;
    editBtn.setAttribute('data-name', 'edit');
    editBtn.appendChild(edit);
    editBtn.addEventListener('click', editUser);
    acoesWrapper.appendChild(editBtn);
    const removeBtn = document.createElement('button');
    removeBtn.type = 'button';
    removeBtn.id = user.id;
    removeBtn.setAttribute('data-name', 'remove');
    const remove = document.createElement('i');
    remove.classList.add('fas');
    remove.classList.add('fa-trash');
    remove.id = user.id;
    remove.setAttribute('data-name', 'remove');
    removeBtn.appendChild(remove);
    removeBtn.addEventListener('click', confirmRemove);
    acoesWrapper.appendChild(removeBtn);
    acoes.appendChild(acoesWrapper);
    tr.appendChild(acoes);      
  });
}

export { tableRows, addZero };