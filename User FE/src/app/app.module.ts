import { AnimeService } from './shared/anime.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {FormsModule , ReactiveFormsModule} from '@angular/forms';

import {ApproutingModule} from './app-routing.module';
import {MenuComponent} from './Components/Blocks/Menu/menu.component';
import {SliderComponent} from './Components/Blocks/Slider/Slider.component';
import {UsersComponent} from './Components/Blocks/Users/Users.component';
import {CategoriesComponent} from './Components/Blocks/Categories/Categories.component';
import {footerComponent} from './Components/Blocks/Footer/Footer.component';
import { HttpClientModule } from '@angular/common/http';




@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SliderComponent,
    UsersComponent,
    CategoriesComponent,
    footerComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    ApproutingModule,
    HttpClientModule,
    FormsModule , ReactiveFormsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [AnimeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
