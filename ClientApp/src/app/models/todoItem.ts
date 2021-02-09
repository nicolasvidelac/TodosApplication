import { todoFolder } from "./todoFolder";

export interface todoItem {
  id: number;
  description: string;
  completed: boolean;
  folder : todoFolder;
}