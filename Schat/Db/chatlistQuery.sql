select distinct receiver_id as Chatlistid from lokesh.messages where sender_id=1
union all
select distinct sender_id as Chatlistid from lokesh.messages where receiver_id=1