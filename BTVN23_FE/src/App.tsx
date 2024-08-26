
import { useEffect, useState } from 'react'
import './App.css'
import { getProducts } from './api/product';
import { Layout } from 'antd';
import Main from './component/Product/Layout';
import { Product } from './interface/Produc';
import CounterComponent from './component/CouterComponent';


function App() {

  const [products, setProducts] = useState<Product[]>([]);

  const fetchProducts = async () => {
    const res = await getProducts();
    const data : Product[] = res.data;
    
    setProducts(data);
  }
  console.log(products);

  useEffect(() => {
    fetchProducts()
  }, [])

  return (
    <>
      <Main products={products} />
    </>
  )
}

export default App
