import { Component } from '@angular/core';
import { HomeService } from 'src/app/services/home.service';
import { ItemFormComponent } from '../item-form/form-item.component';
import { MatDialog } from '@angular/material';
import { todoItem } from 'src/app/models/todoItem';

@Component({
  selector: 'app-item-list',
  templateUrl: './list-item.component.html',
})

export class ItemListComponent {
  items : todoItem[];
  itemDesc = "";
  isCompleted : boolean = false;
  
  constructor( private basicService : HomeService, public dialog : MatDialog ){
    this.listItems();
  }

  listItems(){
    this.basicService.list().subscribe(result => {
      this.items = result
    })
  }

  createItem(){
    if (this.itemDesc != ""){
      this.basicService.create(this.itemDesc).subscribe( result => {
        this.items = result;
        this.itemDesc = "";
      })
    }
  }

  deleteItem(item : todoItem){
    this.basicService.delete(item.id).subscribe( result => {
      this.items = result;
    })
  }

  editItem(item : todoItem){
    this.basicService.patch(item).subscribe( result => {
      this.items = result;
    })
  }

  onCompletedChange(item : todoItem, completed : boolean){
    item.completed = completed;
    this.basicService.patch(item).subscribe( result => {
      this.items = result;
    })
  }

  openDialog(item: todoItem){
    const dialogRef = this.dialog.open(ItemFormComponent, {
      width: '250px',
      data: {description: item.description}
    });

    dialogRef.afterClosed().subscribe(result => {

      try {
        item.description = result.description;
        this.editItem(item);

      } catch (error) {
        console.log(error)
      }
    });
  }
}