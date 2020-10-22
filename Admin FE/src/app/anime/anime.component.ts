import { AnimeService } from './../shared/anime.service';
import { AnimetypeService } from './../shared/animetype.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-anime',
  templateUrl: './anime.component.html',
  styleUrls: ['./anime.component.css']
})
export class AnimeComponent implements OnInit {


  animeForms : FormArray = this.fb.array([]);
  animetypelist = [];
  notification = null;

  constructor(private fb : FormBuilder,
      private animetype :AnimetypeService,
      private service : AnimeService
    ) { }

  ngOnInit(){
    this.animetype.getAnimeTypeList()
    .subscribe(
      res=>this.animetypelist = res as []
    );

   
    
    this.service.getAnime().subscribe(

      res =>{
        if(res ==[])
        this.addAnimeForm();
        else {
          (res as []).forEach(
            (anime : any)=>{
              this.animeForms.push(this.fb.group({
                AnimeID  : [anime.animeID],
                AnimeName : [anime.animeName,Validators.required],
                EpsodesToTal : [anime.epsodesToTal,Validators.required],
                AnimeTypeID : [anime.animeTypeID,Validators.min(1)],
                ViewCount : [anime.viewCount],
                Status : [anime.status],               
                AnimeImg : [anime.animeImg],
               
              }));
            }
          )
        }

      }

    );

   
  }
  addAnimeForm(){
    this.animeForms.push(this.fb.group({
      AnimeID  : [0],
      AnimeName : ['',Validators.required],
      EpsodesToTal : ['',Validators.required],
      AnimeTypeID : [0,Validators.min(1)],
      ViewCount : [''],
      Status : [''],
      CommentID :  [0],
      AnimeImg : [''],
      AnimeVideo : ['']
    }));
  }
  recordSubmit(fg:FormGroup){

    if(fg.value.AnimeID ==0)
    this.service.postAnime(fg.value).subscribe(
      (res : any )=>{
        fg.patchValue({AnimeID : res.AnimeID});
        this.showNotification('insert');
      }
    );

    else 
    this.service.putAnime(fg.value).subscribe(
      (res : any )=>{
        this.showNotification('update');
      }
    );
  }

  onDelete(AnimeID,i){
    if(AnimeID == 0)
    this.animeForms.removeAt(i);
    else if(confirm('Xóa Nhé!!!'))
      this.service.deleteAnime(AnimeID).subscribe(
        res =>{
          this.animeForms.removeAt(i);
          this.showNotification('delete');
        }
      );
  }

  showNotification(category){
    switch (category) {
      case 'insert':
        this.notification = {class: 'text-success',message: 'Đã Lưu!!!'}
        break;

        case 'update':
          this.notification = {class: 'text-primary',message: 'Đã Cập Nhật!!!'}
          break;

          case 'insert':
            this.notification = {class: 'text-danger',message: 'Đã Xóa!!!'}
            break;
    
      default:
        break;
    }
  }

}
