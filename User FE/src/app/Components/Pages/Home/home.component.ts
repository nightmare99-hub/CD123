import { AnimeService } from './../../../shared/anime.service';
import { Anime } from './../../../anime.model';
import {Component} from '@angular/core';

@Component({
    templateUrl: 'home.component.html',
    selector: 'home',
    
})

export class HomeComponent {

    anime$ : Anime[];

    constructor(private animeService:AnimeService){

    }

    ngOnInit() {
      return this.animeService.getAnimes().subscribe(
          data=> this.anime$ = data
      );
        
    }
}