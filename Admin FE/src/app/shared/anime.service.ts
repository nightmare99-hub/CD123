import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {

  constructor(private http: HttpClient) { }

  postAnime(formData){
    return this.http.post(environment.apiBaseURI+'/animes', formData);
  }

  putAnime(formData){
    return this.http.put(environment.apiBaseURI+'/animes/'+formData.AnimeID, formData);
  }

  getAnime(){
    return this.http.get(environment.apiBaseURI+'/animes');
  }

  deleteAnime(id){
    return this.http.delete(environment.apiBaseURI+'/animes/'+ id);
  }
}
