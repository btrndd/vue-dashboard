const menuBtn = document.querySelectorAll('.menu-btn');
const showSidebar = document.querySelector('.show-sidebar');
const main = document.querySelector('.main');

const unhideSidebar = () => {
  const logo = document.querySelector('.logo-hidden');
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
  logo.classList.add('logo')
  sidebar.classList.remove('menu-lateral-hidden');
  sidebar.classList.add('menu-lateral');
  main.classList.remove('main-hidden');
  main.classList.add('main')
  header.classList.remove('header-hidden');
  header.classList.add('header')
  localStorage.clear();
};

const hideSidebar = () => {
  const windowWidth = window.innerWidth;
  if(windowWidth <=768) {
    return;
  }
  const menuLS = localStorage.getItem('menu0');
  if (!menuLS) {
    const logo = document.querySelector('.logo');
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
    logo.classList.add('logo-hidden')
    sidebar.classList.remove('menu-lateral');
    sidebar.classList.add('menu-lateral-hidden');
    main.classList.remove('main');
    main.classList.add('main-hidden')
    header.classList.remove('header');
    header.classList.add('header-hidden')
  } else {
    unhideSidebar();
  }
};

const isBtnFocused = () => {
  console.log('sucesso');
  const btn = document.querySelector('.fa-chevron-right');
  btn.classList.remove('fas');
  btn.classList.remove('fa-chevron-right');
  btn.classList.remove('arrow'); 
};

const toggleArrow = (ev) => {  
  const { id } = ev.target;
  const btns = document.getElementsByTagName('button');
  let btn;
  for (let index = 0; index < btns.length; index += 1) {
    if (btns[index].id === id) {
      btn = btns[index];
    };
  };
  const existingArrow = document.querySelectorAll('.fa-chevron-right');
  if (existingArrow[0]) {
    existingArrow.forEach((e) => {
      e.classList.remove('fas');
      e.classList.remove('fa-chevron-right');
      e.classList.remove('arrow');
      const arrow = document.createElement('i');
      arrow.classList.add('fas');
      arrow.classList.add('fa-chevron-right');
      arrow.classList.add('arrow');
      btn.appendChild(arrow);
    });    
  } else {
    const arrow = document.createElement('i');
    arrow.classList.add('fas');
    arrow.classList.add('fa-chevron-right');
    arrow.classList.add('arrow');
    btn.appendChild(arrow);
  }
}

const usersList = (ev) => {  
  const { id } = ev.target;
  const btns = document.getElementsByTagName('button');
  let btn;
  for (let index = 0; index < btns.length; index += 1) {
    if (btns[index].id === id) {
      btn = btns[index];
    };
  };
  main.innerHTML = '';
  const title = document.createElement('h2');
  title.textContent = 'Usuários';
  const searchBar = document.createElement('input');
  searchBar.placeholder = 'Buscar usuários';
  const addButton = document.createElement('button');
  addButton.type = 'button';
  addButton.textContent = 'Adicionar';
  main.appendChild(title);
  main.appendChild(searchBar);
  main.appendChild(addButton);
}

const handleClick = (ev) => {
  toggleArrow(ev)
  usersList(ev);
}

menuBtn.forEach((btn) => btn.addEventListener('blur', isBtnFocused));
menuBtn.forEach((btn) => {
  if (btn.id === 'usuarios-btn') {
    btn.addEventListener('click', handleClick);
  } 
  if (btn.id === 'dash-btn') {
    btn.addEventListener('click', toggleArrow);
  }
});
showSidebar.addEventListener('click', hideSidebar);