import { ActivatedRoute, Router } from '@angular/router';

import { Component } from '@angular/core';
import { ItemFormComponent } from '../item-form/form-item.component';
import { ItemService } from 'src/app/services/item.service';
import { MatDialog } from '@angular/material';
import { todoItem } from 'src/app/models/todoItem';

@Component({
  selector: 'app-item-list',
  templateUrl: './list-item.component.html',
})

export class ItemListComponent {
  items : todoItem[];
  itemDesc = "";
  idFolder = 0;
  isCompleted : boolean = false;
  
  constructor(private basicService : ItemService, public dialog : MatDialog, private route : ActivatedRoute){
    route.params.subscribe(params => {
      this.idFolder = params.id;
      this.listItems(this.idFolder);

    })
  }

  listItems(id : number){
    this.basicService.list(id).then( result => {
      this.items = result.data;
    })
  }

  createItem(){
    if (this.itemDesc != ""){
      this.basicService.create(this.itemDesc, this.idFolder).then(() => {
        this.listItems(this.idFolder)
        this.itemDesc = "";
      })
    }
  }

  deleteItem(item : todoItem){
    this.basicService.delete(item.id).then(() => {
      this.listItems(this.idFolder)
    });
  }

  editItem(item : todoItem){
    this.basicService.patch(item).then(() => {
      this.listItems(this.idFolder);
    });
  }

  onCompletedChange(item : todoItem, completed : boolean){
    item.completed = completed;
    this.editItem(item);
  }

  openDialog(item: todoItem){
    const dialogRef = this.dialog.open(ItemFormComponent, {
      width: '300px',
      data: {description: item.description}
    });

    dialogRef.afterClosed().subscribe( result => {

      try {
        item.description = result.description;
        this.editItem(item);

      } catch (error) {
      }
    });
  }
}
