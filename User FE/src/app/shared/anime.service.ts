import { Anime } from './../anime.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {

  apiUrl = 'http://localhost:51858/api/animes'

  constructor(private _http : HttpClient) { }

  getAnimes(){
    return this._http.get<Anime[]>(this.apiUrl);
  }

}
