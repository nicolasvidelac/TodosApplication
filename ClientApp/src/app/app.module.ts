import { MatCardModule, MatCheckboxModule, MatDialogModule, MatFormFieldModule } from '@angular/material';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
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
    ItemFormComponent
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
      { path: '', component: ItemListComponent, pathMatch: 'full' },
    ]),
    BrowserAnimationsModule
  ],
  entryComponents: [
    ItemFormComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }