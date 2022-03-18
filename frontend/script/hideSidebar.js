const auth = localStorage.getItem('auth');
localStorage.clear();
localStorage.setItem('auth', auth);

function unhideSidebar() {
  const logo = document.querySelector('.logo-hidden');
  logo.src = './img/logo-branca.png';
  const menus = document.querySelectorAll('.menu-btn-hidden');
  const sidebar = document.querySelector('.menu-lateral-hidden');
  const main = document.querySelector('.main-hidden');
  const header = document.querySelector('.header-hidden');
  menus.forEach((menu, index) => {
    let menuFromLS = localStorage.getItem(`menu${index}`);
    menu.innerHTML = JSON.parse(menuFromLS);
    menu.classList.remove('menu-btn-hidden');
    menu.classList.add('menu-btn');
  });
  logo.classList.remove('logo-hidden');
  logo.classList.add('logo');
  sidebar.classList.remove('menu-lateral-hidden');
  sidebar.classList.add('menu-lateral');
  main.classList.remove('main-hidden');
  main.classList.add('main')
  header.classList.remove('header-hidden');
  header.classList.add('header')
  const auth = localStorage.getItem('auth');
  localStorage.clear();
  localStorage.setItem('auth', auth);
};

function hideSidebar() {
  const windowWidth = window.innerWidth;
  if(windowWidth <=768) {
    return;
  }  
  const menuLS = localStorage.getItem('menu0');
  if (!menuLS) {
    const logo = document.querySelector('.logo');
    logo.src = './img/icon-branco.png';
    const menus = document.querySelectorAll('.menu-btn');
    const sidebar = document.querySelector('.menu-lateral');
    const main = document.querySelector('.main');
    const header = document.querySelector('.header');
    menus.forEach((menu, index) => {
      localStorage.setItem(`menu${index}`, JSON.stringify(menu.innerHTML));
      const child = menu.firstElementChild.nextSibling;
      menu.removeChild(child);
      menu.classList.remove('menu-btn');
      menu.classList.add('menu-btn-hidden');
    });
    logo.classList.remove('logo');
    logo.classList.add('logo-hidden');
    sidebar.classList.remove('menu-lateral');
    sidebar.classList.add('menu-lateral-hidden');
    main.classList.remove('main');
    main.classList.add('main-hidden')
    header.classList.remove('header');
    header.classList.add('header-hidden');
  } else {
    unhideSidebar();
  }
};

export { hideSidebar };