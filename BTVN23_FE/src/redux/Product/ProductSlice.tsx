import { createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'
import { Product } from '../../interface/Produc'



const initialState: Product = {
  id : 0,
  description : '',
  isActive : false,
  name : '', 
  price : 0,
}

// Define the AddProduct type by omitting the id property from Product
export type AddProduct = Omit<Product, 'id'>;

export const ProductSlice = createSlice({
  name: 'product',
  initialState,
  reducers: {
    FetchProduct: (state, action : PayloadAction<Product>) => {
      
    },
    AddProduct: (state, action : PayloadAction<Product>) => {
      // Redux Toolkit allows us to write "mutating" logic in reducers. It
      // doesn't actually mutate the state because it uses the Immer library,
      // which detects changes to a "draft state" and produces a brand new
      // immutable state based off those changes
      state.description = action.payload.description
      state.isActive = action.payload.isActive
      state.name = action.payload.name
      state.price = action.payload.price
    },
   
  },
})

// Action creators are generated for each case reducer function
export const { AddProduct } = ProductSlice.actions

export default ProductSlice.reducer