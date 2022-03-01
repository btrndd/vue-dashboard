export const newUser = async (form) => {

  const formData = new FormData(form);
  
  const request = await fetch("/users", {
    method: "POST",
    body: formData,
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });
  const response = await request.json();
  console.log(response);
}
