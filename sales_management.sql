CREATE DATABASE sales_management;
USE sales_management;

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    name VARCHAR(50),
    price DECIMAL(10, 2),
    stock INT
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    name VARCHAR(50),
    address VARCHAR(100),
    phone VARCHAR(15)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
