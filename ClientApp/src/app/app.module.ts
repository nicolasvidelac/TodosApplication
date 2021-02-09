import { MatCardModule, MatCheckboxModule, MatDialogModule, MatFormFieldModule } from '@angular/material';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FolderFormComponent } from "./views/folder/folder-form/form-folder.component";
import { FolderListComponent } from "./views/folder/folder-list/list-folder.component";
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ItemFormComponent } from './views/item/item-form/form-item.component';
import { ItemListComponent } from './views/item/item-list/list-item.component';
import { MatListModule } from "@angular/material/list";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    ItemListComponent,
    ItemFormComponent,
    FolderFormComponent,
    FolderListComponent
  ],
  imports: [
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
      { path: '', component: FolderListComponent, pathMatch: 'full' },
      { path: 'items/:id', component: ItemListComponent },
      
    ]),
    BrowserAnimationsModule
  ],
  entryComponents: [
    ItemFormComponent,
    FolderFormComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }