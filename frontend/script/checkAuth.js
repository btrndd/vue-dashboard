export const checkAuth = () => {
  const auth = localStorage.getItem('auth');

  
  if (!auth && location.pathname !== '/frontend/login.html') {
    location.assign('login.html');
  }
}