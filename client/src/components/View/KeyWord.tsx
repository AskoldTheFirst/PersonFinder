interface Props {
    keyword: string;
    id: string;
}

export default function KeyWord({ keyword, id }: Props) {
    //console.log(id);
    return (
        <span key={id} style={{ border: '2px', padding: '6px', margin: '6px' }}>
            {keyword}
        </span>
    );
}