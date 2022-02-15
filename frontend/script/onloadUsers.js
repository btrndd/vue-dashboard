import { usersList } from './usersList.js';

const onloadUsers = () => {
  const ev = {
    target: {
      id: 'users',
    }
  };
  const url = ev.target.id;
  history.pushState({}, '', url + '.html');
  usersList(ev);
}

onloadUsers();