const main = document.querySelector('.main');

const table = async () => {
  const tableElement = document.createElement('table');
  main.appendChild(tableElement);
  const trTitles = document.createElement('tr');
  tableElement.appendChild(trTitles);
  const titles = ['Nome', 'Telefone', 'Email', 'Data Nasc.', 'Status', 'Ações'];
  titles.forEach((title) => {
    const th = document.createElement('th');
    th.textContent = title;
    trTitles.appendChild(th);
  });
  const response = await fetch('data.json');
  const data = await response.json();
  data.forEach((user) => {
    const tr = document.createElement('tr');
    tableElement.appendChild(tr);
    const keys = Object.keys(user);
    const filteredKey = keys.slice(1,5);
    filteredKey.forEach((key) => {
      const td = document.createElement('td');
      td.textContent = user[key];
      tr.appendChild(td);
    });
    const status = document.createElement('td');
    status.textContent = 'Ativo';
    tr.appendChild(status); 
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
  table();
}

export { usersList };