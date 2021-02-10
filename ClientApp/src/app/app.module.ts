import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FolderListComponent } from "./views/folder/list-folder.component";
import { HttpClientModule } from '@angular/common/http';
import { ItemFormComponent } from './views/item/item-form/form-item.component';
import { ItemListComponent } from './views/item/item-list/list-item.component';
import { MatListModule } from "@angular/material/list";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './views/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule,MatMenuModule, MatIconModule, MatButtonModule, MatCheckboxModule, MatDialogModule, MatFormFieldModule, MatTableModule,MatDividerModule, MatProgressSpinnerModule, MatInputModule, MatCardModule, MatSlideToggleModule, MatSelectModule, MatOptionModule} from '@angular/material';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuardService } from './services/auth-guard.service';
import { HomeComponent } from './views/home/home.component';

export function tokenGetter(){
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    ItemListComponent,
    ItemFormComponent,
    FolderListComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatInputModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatDividerModule,
    MatSlideToggleModule,
    MatSelectModule,
    MatOptionModule,
    MatProgressSpinnerModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatListModule,
    MatDialogModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatCardModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'folders', component: FolderListComponent, canActivate: [AuthGuardService] },
      { path: 'folders/items/:id', component: ItemListComponent, canActivate: [AuthGuardService] },
      
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    }),
    BrowserAnimationsModule
  ],
  entryComponents: [
    ItemFormComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }