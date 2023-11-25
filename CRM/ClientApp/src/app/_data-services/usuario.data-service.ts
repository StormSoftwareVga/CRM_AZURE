import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class UsuarioDataService {
    module: string = '/api/usuario';

    constructor(private http: HttpClient) { }

    get() {
        return this.http.get(this.module);
    }

    post(dados) {
        return this.http.post(this.module, dados);
    }

    put(dados) {
        return this.http.put(this.module, dados);
    }

    deleteMe() {
        return this.http.delete(this.module);
    }

    delete(userId) {
        return this.http.delete(this.module + '/' + userId);
    }

    autenticar(dados) {
        return this.http.post(this.module + '/autenticate', dados);
    }
}

