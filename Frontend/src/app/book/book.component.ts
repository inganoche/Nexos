import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../model/book';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  books: Book[];
  filterBook: "";

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.getAllBooks();
  }

  getAllBooks() {
    this.bookService.getAllBooks().subscribe(books =>
      this.books = books
    );
  }

  

}
