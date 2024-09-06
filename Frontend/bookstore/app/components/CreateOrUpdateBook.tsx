import { Input, Modal } from "antd";
import TextArea from "antd/es/input/TextArea";
import { useEffect, useState } from "react";
import { BookRequest } from "../services/books";

interface Props{
    mode: Mode;
    values: Book;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: BookRequest) => void;
    handleUpdate: (id: string, request: BookRequest) => void;
}

export enum Mode{
    Create, Update
}

export const CreateOrUpdate = ({mode, values, isModalOpen, handleCancel, handleCreate, handleUpdate} : Props) => {
    const [title, setTitle] = useState<string>(""); 
    const [description, setDescription] = useState<string>(""); 
    const [price, setPrice] = useState<number>(1); 

    useEffect(() => {
        setTitle(values.title);
        setDescription(values.description)
        setPrice(values.price)
    }, [values]);

    const handleOk = async () => {
        const bookRequest = {title, description, price}

        mode == Mode.Create ? handleCreate(bookRequest) : handleUpdate(values.id, bookRequest  );
    }

    return(
        <Modal title={mode === Mode.Create ? "Добавить книгу" : "Редактирование книги"} 
               open={isModalOpen}
               cancelText={"cancel"}
               onOk={handleOk}
               onCancel={handleCancel}>
            
            <div className="book-modal">
                <Input value={title} onChange={(e) => setTitle(e.target.value)} placeholder="Название"/>

                <TextArea value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Описание"/>

                <Input value={price} onChange={(e) => setPrice(Number(e.target.value))} placeholder="Цена"/>
            </div>
        </Modal>
    )
}