import React from 'react'

import './Cart.css'

import ProductListItem from '../ProductListItem/'

const Cart = props => {

  const cartData = props.data;
  console.log(cartData)
  return (
    <div className="cart-container">
      <img alt="Exit button for checkout" className="exit-icon" onClick={props.toggleCart} height="25" width="25" src="https://image.flaticon.com/icons/svg/109/109602.svg"/>
      <h2>CART</h2>
      {cartData.map((item, key) => <ProductListItem key={key} data={item.product_id} /> )}
      <button onClick={props.clearCart}>Clear Cart</button>
      {cartData.length > 0 && <button onClick={props.toggleCheckout}>Checkout</button>}
    </div>
  )

}

export default Cart
