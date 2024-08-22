import React from 'react';
import { Button, Space, Table, Tag } from 'antd';
import type { TableProps } from 'antd';
import { ProductListProps } from './Layout';
import { Product } from '../interface/Produc';
import { ColumnsType } from 'antd/es/table';

interface DataType {
  key: string;
  name: string;
  age: number;
  address: string;
  tags: string[];
}
const handleDelete = (id: number) => {
  console.log(`Delete product with id: ${id}`);
  // Implement delete logic here
};

const handleUpdate = (id: number) => {
  console.log(`Update product with id: ${id}`);
  // Implement update logic here
};

const columns: ColumnsType<Product> = [
  {
    title: 'Id',
    dataIndex: 'id',
    key: 'id',
  },
  {
    title: 'Name',
    dataIndex: 'name',
    key: 'name',
  },
  {
    title: 'Description',
    dataIndex: 'description',
    key: 'description',
  },
  {
    title: 'Price',
    dataIndex: 'price',
    key: 'price',
  },
  {
    title: 'Is Active',
    dataIndex: 'isActive',
    key: 'isActive',
    render: (isActive: boolean) => (isActive ? 'Yes' : 'No'),
  },
  {
    title: 'Actions',
    key: 'actions',
    render: (_, record: Product) => (
      <>
        <Button onClick={() => handleUpdate(record.id)} type="primary" style={{ marginRight: 8 }}>
          Update
        </Button>
        <Button onClick={() => handleDelete(record.id)} type="primary" style={{ backgroundColor: 'red', borderColor: 'red' }}>
          Delete
        </Button>
      </>
    ),
  },
];



const TableCustom: React.FC<ProductListProps> = ({ products }) => {
  console.log(products)
  return <Table columns={columns} dataSource={products} />
};

export default TableCustom;