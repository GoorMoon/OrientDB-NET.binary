OrientDB-NET.binary is C#/.NET driver for [OrientDB](http://www.orientdb.org/) document/graph database which implements network binary protocol.

Congratulation now OrientDB-NET.binary is official supported by the [OrientDB](http://www.orientdb.org/) if you want to download and test this driver please do this from this repository [orientechnologies/OrientDB-NET.binary](https://github.com/orientechnologies/OrientDB-NET.binary)

Check out [wiki docs](https://github.com/yojimbo87/OrientDB-NET.binary/wiki) to learn more.

[![Gitter](https://badges.gitter.im/Join Chat.svg)](https://gitter.im/GoorMoon/OrientDB-NET.binary?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This fork contains the following improvements

* Better handling of ordered edges
* Support for LoadRecord and CreateRecord operations - faster than performing the same action via SQL commands
* Improved mapping code for generic types to/from ODocuments - much faster, avoids repeated reflection
* Support for fetch plans using LoadRecord to pull back a whole tree of objects in one request
* Initial support for transactional create/update/delete - should be much faster than multiple individual SQL commands
* Better support for derived types - .ToUnique<TBase> will construct a TDerived if the database record is of type TDerived

Fetching a large block of records from the DB via Database.Load.ORID(orid).FetchPlan(plan) and converting them to typed objects about 6 times faster than original code using SQL commands and old mapping
