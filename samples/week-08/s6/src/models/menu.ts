export type Menu = {
    id:string,
    name: string
}
export type MenuItem={
    id?:string,
    name:string,
    price: number
}
export type MenuDetails = {
    id:string,
    name: string,
    menuItems: MenuItem[]
}