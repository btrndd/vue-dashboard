import ApiService from "@/api/api.service";

const UsersService = {
  async list() {
    try {
      const { data } = await ApiService.get('users');
      return data;
    } catch (error) {
      return error.response.data;
    }    
  },
  async save(form, id) {
    try {
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
    } catch (error) {
      return error.response.data;
    }    
  },
  async getById(id) {
    try {
      const { data } = await ApiService.get('users', id);
      data.birthDate = new Date(data.birthDate).toISOString().split('T')[0];
      return data;
    } catch (error) {
      return error.response.data;
    }    
  },
  async remove(id) {
    try {
      const { data } = await ApiService.delete('users', id);
      return data;
    } catch (error) {
      return error.response.data;
    }    
  },
  async login(form) {
    try {
      const { data } = await ApiService.post('login', {...form});
      return data;
    } catch (error) {
      return error.response.data;
    }
  },
}

export default UsersService;