const main = document.querySelector('.main');

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

const tableRows = async (page) => {
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newMain = newHtml.querySelector('.main');
  main.innerHTML = newMain.innerHTML;
  const table = document.querySelector('table');
  const response = await fetch('data.json');
  const data = await response.json();
  const tr = document.createElement('tr');
  tr.classList.add('separator');
  table.appendChild(tr);
  data.forEach((user, index) => {
    const tr = document.createElement('tr');
    tr.classList.add('user-row');
    table.appendChild(tr);
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

const getData = async(data) => {
  const request = new Request(data + '.html');
  const response = await fetch(request);
  const page = await response.text();
  return page;
}

const usersList = async (ev) => {
  const { id } = ev.target;
  const btns = document.getElementsByTagName('button');
  let btn;
  for (let index = 0; index < btns.length; index += 1) {
    if (btns[index].id === id) {
      btn = btns[index];
    };
  };
  main.innerHTML = '';
  const linkData = ev.target.getAttribute('data-page');
  const response = await getData(linkData);
  tableRows(response);
}

export { usersList };