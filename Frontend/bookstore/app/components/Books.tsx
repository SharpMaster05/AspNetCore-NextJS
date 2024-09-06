import { Card } from "antd";
import Button from "antd/es/button/button";
import { CardTitle } from "./CardTitle";

interface Props{
    books: Book[];
    handleDelete: (id: string) => void;
    handleOpen: (book: Book) => void;
}

export const Books = ({books, handleOpen, handleDelete}: Props) => {
    return (
        <div className="card">
            {books.map((book: Book) => (
                <Card key={book.id} 
                      title={
                        <CardTitle title={book.title} 
                                   price={book.price}/>
                      } 
                      bordered={false}>
                    
                    <p>{book.description}</p>
                    <div className="card-button">
                      <Button onClick={() => handleOpen(book)} style={{flex: 1}}>
                        Edit
                      </Button>

                      <Button onClick={() => handleDelete(book.id)} danger style={{flex: 1}}>
                        Delete
                      </Button>
                    </div>
                </Card>
            ))}
        </div>
    );
}