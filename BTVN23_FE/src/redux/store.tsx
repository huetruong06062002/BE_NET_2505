import { configureStore } from '@reduxjs/toolkit'
import counterReducer from './CounterSlice'
import productReducer from './Product/ProductSlice'


export const store = configureStore({
  reducer: {
    product : productReducer
  },
})

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch