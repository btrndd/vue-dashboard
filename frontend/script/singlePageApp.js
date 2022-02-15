import { hideSidebar } from './hideSidebar.js';
import { toggleArrow } from './toggleArrow.js';
import { usersList } from './usersList.js';

const showSidebar = document.querySelector('.show-sidebar');

const isBtnFocused = () => {
  const btn = document.querySelector('.fa-chevron-right');
  if (btn) {
    btn.classList.remove('fas');
    btn.classList.remove('fa-chevron-right');
    btn.classList.remove('arrow');
  }
};

const handleUsersClick = (ev) => {
  toggleArrow(ev)
  const url = ev.target.getAttribute('data-page');
  history.pushState({}, '', url + '.html');
  document.title = 'Usuários';
  usersList(ev);
}

const handleDashClick = (ev) => {
  toggleArrow(ev)
  const url = ev.target.getAttribute('data-page');
  history.pushState({}, '', url + '.html');
  document.title = 'Dashboard';
  const main = document.querySelector('.main') || document.querySelector('.main-hidden');
  main.innerHTML = '';
  const title = document.createElement('h1');
  title.classList.add('title');
  title.textContent = 'Bem vindo a Lyncas';
  main.appendChild(title);
}

const spaFunction = () => {
  const menuBtn = document.querySelectorAll('.menu-btn');
  const menuBtnHidden = document.querySelectorAll('.menu-btn-hidden');
  if (menuBtn) {
    menuBtn.forEach((btn) => btn.addEventListener('blur', isBtnFocused));
    menuBtn.forEach((btn) => {
      if (btn.id === 'users') {
        btn.addEventListener('click', handleUsersClick);
      } 
      if (btn.id === 'dashboard') {
        btn.addEventListener('click', handleDashClick);
      }
    })
  } else {
    menuBtnHidden.forEach((btn) => btn.addEventListener('blur', isBtnFocused));
    menuBtnHidden.forEach((btn) => {
      if (btn.id === 'users') {
        btn.addEventListener('click', handleUsersClick);
      } 
      if (btn.id === 'dashboard') {
        btn.addEventListener('click', handleDashClick);
      }
    })
  }
}

spaFunction();

showSidebar.addEventListener('click', hideSidebar);

window.onresize = () => {
  if (window.innerWidth <= 1280) {
    const logo = document.querySelector('.logo');
    if (logo) {
      logo.src = './img/icon-branco.png';
    }
  }
  if (window.innerWidth > 1280) {
    const logo = document.querySelector('.logo');
    if (logo) {
      logo.src = './img/logo-branca.png';
    }
  }
}

window.onload = () => {
  if (window.innerWidth <= 1280) {
    const logo = document.querySelector('.logo');
    if (logo) {
      logo.src = './img/icon-branco.png';
    }
  }
  if (window.innerWidth > 1280) {
    const logo = document.querySelector('.logo');
    if (logo) {
      logo.src = './img/logo-branca.png';
    }
  }
}