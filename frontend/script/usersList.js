const main = document.querySelector('.main');

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
    th.textContent = title;
    trTitles.appendChild(th);
  });
  const response = await fetch('data.json');
  const data = await response.json();
  const tr = document.createElement('tr');
    tr.classList.add('separator');
    tableElement.appendChild(tr);
  data.forEach((user) => {
    const tr = document.createElement('tr');
    tr.classList.add('user-row');
    tableElement.appendChild(tr);
    const keys = Object.keys(user);
    const filteredKey = keys.slice(1,6);
    filteredKey.forEach((key) => {
      if (user[key] === true) {
        const td = document.createElement('td');
        td.textContent = 'Ativo';
        tr.appendChild(td);
      } else if (user[key] === false) {
        const td = document.createElement('td');
        td.textContent = 'Inativo';
        tr.appendChild(td);
      } else {
        const td = document.createElement('td');
        td.textContent = user[key];
        tr.appendChild(td);
      }     
    });
    const acoes = document.createElement('td');
    acoes.textContent = 'i';
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
  const addButton = document.createElement('button');
  addButton.classList.add('add-button');
  addButton.type = 'button';
  addButton.textContent = 'Adicionar';
  container.appendChild(title);
  container.appendChild(searchWrapper);
  searchWrapper.appendChild(searchBar);
  searchWrapper.appendChild(addButton);
  table();
}

export { usersList };