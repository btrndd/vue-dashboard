export const basicAuth = () => {
  const auth = JSON.parse(localStorage.getItem('auth'));
  const credentials = btoa(auth.email + ':' + auth.password);
  const header = {
    "Authorization": `Basic ${credentials}`
  };
  return header;
}