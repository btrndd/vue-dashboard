export const basicAuth = () => {
  const auth = JSON.parse(localStorage.getItem('auth'));
  console.log(btoa(auth.email + ':' + auth.password));
  const credentials = btoa(auth.email + ':' + auth.password);
  const header = {
    "Authorization": `Basic ${credentials}`
  };
  return header;
}