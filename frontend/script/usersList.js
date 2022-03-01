import { registerForm } from './registerForm.js';
import { tableRows } from './tableRows.js';

const main = document.querySelector('.main');

const createTable = async (page) => {
  main.innerHTML = '';
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newMain = newHtml.querySelector('.main');
  main.innerHTML = newMain.innerHTML;  
  const response = await fetch('data.json');
  const data = await response.json();
  // tableRows - Cria e popula a linhas da tabela com o usuários
  tableRows(data);    
  const registerBtn = document.getElementById('register');
if (registerBtn) {
    registerBtn.addEventListener('click', (ev) => {
      const url = ev.target.getAttribute('data-page');
      history.pushState({}, '', url + '.html');
      document.title = 'Cadastrar';
      registerForm(ev);
    });
  }
}

const getData = async (data) => {
  const request = new Request(data + '.html');
  const response = await fetch(request);
  const page = await response.text();
  return page;
}

const usersList = async (ev) => {
  const { id } = ev.target;
  const response = await getData(id);
  createTable(response);
}

export { usersList };