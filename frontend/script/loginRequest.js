export const loginRequest = async (email, password) => {
  const body = {
    email,
    password
  };
  
  const json = JSON.stringify(body);
  
  const request = await fetch("https://localhost:7271/login", {
    method: "POST",
    body: json,
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    },
  });
  
  const response = await request.json();
  return response;
}