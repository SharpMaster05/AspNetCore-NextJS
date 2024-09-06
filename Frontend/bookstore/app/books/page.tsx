"use client";

import Button from "antd/es/button/button";
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import { Books } from "../components/Books";
import { CreateOrUpdate, Mode } from "../components/CreateOrUpdateBook";
import { BookRequest, createBook, deleteBook, getAllBooks, updateBook } from "../services/books";

export default function BookPage(){ 
    const defaultValues = {
        title: "",
        description: "",
        price: 1
    } as Book;

    const [values, setValues] = useState<Book>(defaultValues);

    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setisModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);

    

    useEffect(() => {
        const getBooks = async () => {
            const books: Book[] = await getAllBooks();
            setLoading(false);
            setBooks(books);
        };

        getBooks();
    }, [])
    
    const handleCreateBook = async (request: BookRequest) => {
        await createBook(request);

        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    }
    
    const handleUpdate = async (id: string, request: BookRequest) => {
        await updateBook(id, request);
        
        closeModal();

        const books = await getAllBooks();
        setBooks(books);
    }
   
    const handleDelete = async (id: string) => {
        await deleteBook(id);
        
        const books = await getAllBooks();
        setBooks(books);
    }

    const openModal = async () => {
        setisModalOpen(true);
    }

    const closeModal = async () => {
        setValues(defaultValues);
        setisModalOpen(false);
    }

    const openUpdateModal = (book: Book) => {
        setMode(Mode.Update);
        setValues(book);
        setisModalOpen(true);
    }

    return(
        <div>
            <Button onClick={openModal}>Добавить книгу</Button>
            
            <CreateOrUpdate 
                mode={mode} 
                values={values}
                isModalOpen={isModalOpen} 
                handleCreate={handleCreateBook} 
                handleUpdate={handleUpdate}
                handleCancel={closeModal}/>

            {loading ? <Title>Loading...</Title> : <Books books={books} handleOpen={openUpdateModal} handleDelete={handleDelete}></Books>}
        </div>
    )
}