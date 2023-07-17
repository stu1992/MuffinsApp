import { MuffinView } from './MuffinView';
const ListView = (items) => {
    return(
<ol>
	{items.map(item => <MuffinView type={item.type} />)}
</ol>
)

}
export { ListView }