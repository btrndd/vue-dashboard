import ApiService from "@/api/api.service";

const UsersService = {
  async list() {
    const { data } = await ApiService.get('users');
    return data;
  },
  async save(form, id) {
    if (id !== undefined) {
      delete form.checkPassword;      
      if (!form.password) {
        delete form.password;
      }  
      const { data } = await ApiService.put('users', {...form}, id);
      return data;
    }
    const { data } = await ApiService.post('users', {...form});
    return data;
  },
  async getById(id) {
    const { data } = await ApiService.get('users', id);
    data.birthDate = new Date(data.birthDate).toISOString().split('T')[0];
    return data;
  }
}

export default UsersService;