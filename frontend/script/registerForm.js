const main = document.querySelector('.main');

const formInjection = async (page) => {
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newMain = newHtml.querySelector('.main');
  main.innerHTML = newMain.innerHTML;
}

const getData = async(data) => {
  const request = new Request(data + '.html');
  const response = await fetch(request);
  const page = await response.text();
  return page;
}

const registerForm = async (ev) => {
  const { id } = ev.target;
  console.log(id);
  main.innerHTML = '';
  const response = await getData(id);
  await formInjection(response);
}

export { registerForm };