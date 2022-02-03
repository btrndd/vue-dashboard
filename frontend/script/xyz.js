const menuBtn = document.querySelectorAll('.menu-btn');
const showSidebar = document.querySelector('.show-sidebar');

const hideSidebar = () => {
  const windowWidth = window.innerWidth;
  if(windowWidth <=768) {
    return;
  }
  const logo = document.querySelector('.logo');
  const menus = document.querySelectorAll('.menu-btn');
  const sidebar = document.querySelector('.menu-lateral');
  const main = document.querySelector('.main');
  const header = document.querySelector('.header');
  const menuLS = localStorage.getItem('menu0');
  if (!menuLS) {
    menus.forEach((menu, index) => {
      localStorage.setItem(`menu${index}`, JSON.stringify(menu.innerHTML));
      const child = menu.lastChild;
      menu.removeChild(child);
      menu.style.width = '60px';
    });
    logo.style.display = 'none';
    sidebar.style.width = '60px';
    sidebar.classList.remove('manu-lateral');
    sidebar.classList.add('menu-lateral-hidden');
    main.style.marginLeft = '60px';
    header.style.marginLeft = '60px';
  } else {
    menus.forEach((menu, index) => {
      let menuFromLS = localStorage.getItem(`menu${index}`);
      menu.innerHTML = JSON.parse(menuFromLS);
      menu.style.width = '250px';
    });
    logo.style.display = '';
    sidebar.style.width = '250px';
    sidebar.classList.remove('menu-lateral-hidden');
    sidebar.classList.add('menu-lateral');
    main.style.marginLeft = '250px';
    header.style.marginLeft = '250px';
    localStorage.clear();
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

menuBtn.forEach((btn) => btn.addEventListener('blur', isBtnFocused));
menuBtn.forEach((btn) => btn.addEventListener('click', toggleArrow));
showSidebar.addEventListener('click', hideSidebar);