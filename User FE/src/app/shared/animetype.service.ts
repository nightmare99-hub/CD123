import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AnimetypeService {

  constructor(private http: HttpClient) { }

 getAnimeTypeList(){
   this.http.get(environment.apiBaseURI + '/AnimeTypes')
 }
}
