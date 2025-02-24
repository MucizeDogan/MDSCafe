﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class NotificationManager : INotificationService {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal) {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity) {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity) {
            _notificationDal.Delete(entity);
        }

        public Notification TGetById(int id) {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll() {
           return _notificationDal.GetListAll();
        }

        public void TUpdate(Notification entity) {
            _notificationDal.Update(entity);
        }

        public int TNotificationCountByStatusFalse() {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public List<Notification> TGetAllNotificationByStatusFalse() {
            return _notificationDal.GetAllNotificationByStatusFalse();
        }

        public void TNotificationChangeToTrue(int id) {
            _notificationDal.NotificationChangeToTrue(id);
        }

        public void TNotificationChangeToFalse(int id) {
            _notificationDal.NotificationChangeToFalse(id);
        }

        public void TDeleteAllNotificationByTrue() {
            _notificationDal.DeleteAllNotificationByTrue();
        }
    }
}
