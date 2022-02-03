const menuBtn = document.querySelectorAll('.menu-btn');

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