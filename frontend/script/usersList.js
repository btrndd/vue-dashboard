const main = document.querySelector('.main');
const arrowButtons = (th) => {
  const arrowsWrapper = document.createElement('div');
  const btnArrowUp = document.createElement('button');
  btnArrowUp.type = 'button';
  const btnArrowDown = document.createElement('button');
  btnArrowDown.type = 'button';
  const arrowUp = document.createElement('i');
  arrowUp.classList.add('fas');
  arrowUp.classList.add('fa-arrow-up')
  btnArrowUp.appendChild(arrowUp);
  arrowsWrapper.appendChild(btnArrowUp);
  const arrowDown = document.createElement('i');
  arrowDown.classList.add('fas');
  arrowDown.classList.add('fa-arrow-down');
  btnArrowDown.appendChild(arrowDown);
  arrowsWrapper.appendChild(btnArrowDown);
  th.appendChild(arrowsWrapper);
}

const insertAvatar = async (user, index) => {
  const firstTds = document.querySelectorAll('.user-row');
  firstTds[index].firstChild.textContent = '';
  const wrapper = document.createElement('div');
  wrapper.classList.add('name-wrapper');
  const img = document.createElement('img');
  img.classList.add('list-avatar');
  img.src = user.avatar;
  const name = document.createElement('p');
  name.classList.add('name-text');
  name.textContent = user.name;
  wrapper.appendChild(img);
  wrapper.appendChild(name);
  firstTds[index].firstChild.appendChild(wrapper);
}

const translateKeys = (key) => {
  switch (key) {
    case 'name':
      return 'Nome';
    case 'phonenumber':
      return 'Telefone';
    case 'email':
      return 'Email';
    case 'birth':
      return 'Data Nasc.';
    case 'status':
      return 'Status';
  }
}

const table = async () => {
  const tableElement = document.createElement('table');
  main.appendChild(tableElement);
  const trTitles = document.createElement('tr');
  trTitles.classList.add('table-header');
  tableElement.appendChild(trTitles);
  const titles = ['Nome', 'Telefone', 'Email', 'Data Nasc.', 'Status', 'Ações'];
  titles.forEach((title) => {
    const th = document.createElement('th');
    th.classList.add('header-items');
    const thWrapper = document.createElement('div');
    thWrapper.classList.add('th-wrapper');
    const titleText = document.createElement('p');
    titleText.textContent = title;
    thWrapper.appendChild(titleText);
    arrowButtons(thWrapper);
    th.appendChild(thWrapper);
    trTitles.appendChild(th);
  });
  const response = await fetch('data.json');
  const data = await response.json();
  const tr = document.createElement('tr');
  tr.classList.add('separator');
  tableElement.appendChild(tr);
  data.forEach((user, index) => {
    const tr = document.createElement('tr');
    tr.classList.add('user-row');
    tableElement.appendChild(tr);
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
    const editBtn = document.createElement('button');
    editBtn.type = 'button';
    editBtn.appendChild(edit);
    acoesWrapper.appendChild(editBtn);
    const removeBtn = document.createElement('button');
    removeBtn.type = 'button';
    const remove = document.createElement('i');
    remove.classList.add('fas');
    remove.classList.add('fa-trash');
    removeBtn.appendChild(remove);
    acoesWrapper.appendChild(removeBtn);
    acoes.appendChild(acoesWrapper);
    tr.appendChild(acoes);      
  })
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
  const container = document.createElement('div');
  container.classList.add('container');
  main.appendChild(container);
  const title = document.createElement('h2');
  title.textContent = 'Usuários';
  const searchWrapper = document.createElement('div');
  searchWrapper.classList.add('search-wrapper');
  const searchBar = document.createElement('input');
  searchBar.classList.add('search-bar');
  searchBar.placeholder = 'Buscar usuários';
  const searchLabel = document.createElement('label');
  const lupa = document.createElement('i');
  lupa.classList.add('fas');
  lupa.classList.add('fa-search');
  searchLabel.appendChild(lupa);
  const addButton = document.createElement('button');
  addButton.classList.add('add-button');
  addButton.type = 'button';
  addButton.textContent = 'Adicionar';
  container.appendChild(title);
  container.appendChild(searchWrapper);
  searchWrapper.appendChild(searchLabel);
  searchWrapper.appendChild(searchBar);
  searchWrapper.appendChild(addButton);
  table();
}

export { usersList };