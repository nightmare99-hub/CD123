import { AnimeService } from './../../../shared/anime.service';
import { Anime } from './../../../anime.model';
import {Component} from '@angular/core';

@Component({
    templateUrl: 'detail.component.html',
    selector: 'detail',
    
})

export class DetailComponent {
    anime$ : Anime[];

    constructor(private animeService:AnimeService){

    }

    ngOnInit() {
      return this.animeService.getAnimes().subscribe(
          data=> this.anime$ = data
      );
        
    }
}