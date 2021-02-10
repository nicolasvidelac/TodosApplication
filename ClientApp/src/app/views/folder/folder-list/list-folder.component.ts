import { Component } from '@angular/core';
import { FolderFormComponent } from '../folder-form/form-folder.component';
import { FolderService } from 'src/app/services/folder.service';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { todoFolder } from 'src/app/models/todofolder';

@Component({
  selector: 'app-folder-list',
  templateUrl: './list-folder.component.html',
})

export class FolderListComponent {
  folders : todoFolder[];
  folderDesc = "";
  isCompleted : boolean = false;
  
  constructor( private basicService : FolderService, public dialog : MatDialog, public router : Router ){
    this.listfolders();
  }

  listfolders(){
    this.basicService.list().then(result => {
      try {
        this.folders = result.data
      } catch (error) {
        this.folders = []
      }
    })
  }

  createfolder(){
    if (this.folderDesc != ""){
      this.basicService.create(this.folderDesc).then( () => {
        this.listfolders();
        this.folderDesc = "";
      })
    }
  }

  deletefolder(folder : todoFolder){
    this.basicService.delete(folder.id).then( () => {
      this.listfolders();
    })
  }

  openItems(id : number){
    this.router.navigate(['folders/items/', id])
  }

}