import { hideSidebar } from './hideSidebar.js';
import { toggleArrow } from './toggleArrow.js';
import { usersList } from './usersList.js';

const menuBtn = document.querySelectorAll('.menu-btn');
const showSidebar = document.querySelector('.show-sidebar');

const isBtnFocused = () => {
  const btn = document.querySelector('.fa-chevron-right');
  btn.classList.remove('fas');
  btn.classList.remove('fa-chevron-right');
  btn.classList.remove('arrow'); 
};

const handleUsersClick = (ev) => {
  toggleArrow(ev)
  usersList(ev);
}

const handleDashClick = (ev) => {
  toggleArrow(ev)
  const main = document.querySelector('.main');
  main.innerHTML = '';
  const title = document.createElement('h1');
  title.classList.add('title');
  title.textContent = 'Bem vindo a Lyncas';
  main.appendChild(title);
}

menuBtn.forEach((btn) => btn.addEventListener('blur', isBtnFocused));
menuBtn.forEach((btn) => {
  if (btn.id === 'usuarios-btn') {
    btn.addEventListener('click', handleUsersClick);
  } 
  if (btn.id === 'dash-btn') {
    btn.addEventListener('click', handleDashClick);
  }
});
showSidebar.addEventListener('click', hideSidebar);