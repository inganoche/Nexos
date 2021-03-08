import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, arg: string): any {
    let result = new Array();

    if (value != null) {
      if (arg === undefined) {
        result = [...value];
        return result;
      }

      if (arg.length === 0) {
        result = [...value];
        return result;
      }
      for (const book of value) {
         const filter = arg.toLowerCase();

        if (book.title.toLowerCase().indexOf(filter) > -1 || `${book.year}`.indexOf(filter) > -1 || book.gender.toLowerCase().indexOf(filter) > -1
          || book.nameEditorial.toLowerCase().indexOf(filter) > -1 || book.nameAuthor.toLowerCase().indexOf(filter) > -1) {
          result.push(book);
        }
      }
    }
    return result;
  }

}
