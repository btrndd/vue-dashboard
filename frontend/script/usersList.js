import { loadingSpinner } from './loadingSpinner.js';
import { registerForm } from './registerForm.js';
import { tableRows } from './tableRows.js';

const main = document.querySelector('.main') || document.querySelector('.main-hidden');

const createTable = async (page) => {
  main.innerHTML = '';
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newMain = newHtml.querySelector('.main');
  main.innerHTML = newMain.innerHTML;  
  const response = await fetch('https://localhost:7271/users');
  const data = await response.json();
  // tableRows - Cria e popula a linhas da tabela com o usuários
  tableRows(data);    
  const registerBtn = document.getElementById('register');
if (registerBtn) {
    registerBtn.addEventListener('click', (ev) => {
      const url = ev.target.getAttribute('data-page');
      history.pushState({}, '', url + '.html');
      document.title = 'Cadastrar';
      const edit = 'register';
      registerForm(ev, edit);
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
  const spinner = document.querySelector('.spinner');
  loadingSpinner(main);
  const responseCard = document.querySelector('.request');
  if (responseCard) {
    setTimeout(() => {
      responseCard.style.visibility = 'hidden';
    }, 2000);
  };
  const { id } = ev.target;
  const response = await getData(id);
  if (spinner) {
    spinner.style.visibility = 'hidden';
  }
  createTable(response);
}

export { usersList };