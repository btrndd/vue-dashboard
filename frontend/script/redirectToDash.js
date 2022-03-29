
import { spaFunction } from "./singlePageApp.js";
import { updateUserName } from "./updateUserName.js";

const getData = async (id) => {
  const request = new Request(id + '.html');
  const response = await fetch(request);
  const page = await response.text();
  return page;
}

const redirectToDash = async (response) => {
  const ev = {
    target: {
      id: 'dashboard',
    }
  };
  const id = ev.target.id;
  history.pushState({}, '', id + '.html');
  document.title = 'Dashboard';

  const card = document.querySelector('.request');

  if (window.innerWidth <= 1280) {
    card.style.left = '60px';
  } else {
    card.style.left = '250px';
  }

  if (card) {    
    setTimeout(() => {
      const parent = card.parentElement;
      parent.removeChild(card);
    }, 2000);
  }

  const div = document.querySelector('.wrapper');
  const page = await getData(id);
  
  div.innerHTML = '';
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newDiv = newHtml.querySelector('.all');
  div.innerHTML = newDiv.innerHTML;

  const script = document.querySelector("[type='module']")
  script.src = './script/singlePageApp.js';
  
  await updateUserName(response.data.id);

  spaFunction();
  localStorage.setItem('auth', JSON.stringify(response.data));

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

export { redirectToDash };