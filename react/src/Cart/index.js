import React from 'react'

import './Cart.css'

import ProductListItem from '../ProductListItem/'

const Cart = props => {

  const cartData = props.data;
  return (
    <div className="cart-container">
      <button onClick={props.clearCart}>Clear Cart</button>
      <button onClick={props.toggleCheckout}>Checkout</button>
      <h4>Cart</h4>
      {cartData.map(item => <ProductListItem data={item} /> )}
    </div>
  )

}

export default Cart
